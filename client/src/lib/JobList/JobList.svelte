<script lang="ts">
	import TrashIcon from '@src/lib/Icons/TrashIcon.svelte';
	import { JobListStore } from '@src/store/JobListStore'; 
	import type { JobEntry } from '@src/store/JobListStore';
	import EntryCard from './EntryCard.svelte';

	//TODO: Sort direction
	//? What is the best way to do this type? Is it defined? KeyOf(job)
	export let sortBy: "company" | "contact" | "interest" | "posting";
	
	let collapsedEntries = false;

	const toggleCollapsedEntries = () => (collapsedEntries = !collapsedEntries);
	
	//TODO: refactor into generic typed sortObjectList
	//TODO: refactor as a utility function
	//TODO: thoroughly test this function
	const sortJobList = (list: Array<JobEntry>, term: "company" | "contact" | "interest" | "posting"): Array<JobEntry> => {
		let sortedList: Array<JobEntry> = [];
		list.forEach(job => {
			for(let i = 0; i < sortedList.length; i++){
				//TODO: fix "may be undefined" type error
				if (job[term] < sortedList[i][term]) {
					sortedList = [...sortedList.slice(0, i), job, ...sortedList.slice(i, sortedList.length)];
					return;
				}
			}
			sortedList = [...sortedList, job];
		});
		return sortedList;
	}

	$: jobCount = $JobListStore.length;
	$: sortedList = sortJobList($JobListStore, sortBy);
</script>

<section class="flex flex-col self-stretch">
	<div class="flex justify-end items-center gap-3">
		<p>Jobs ({jobCount})</p>
		<button class="btn btn-outline btn-sm" on:click={toggleCollapsedEntries}>
			{#if !collapsedEntries}Collapse{:else}Expand{/if}
		</button>
	</div>
	<ul>
		{#each sortedList as job}
			<li class="py-2">
				<EntryCard {job} collapsed={collapsedEntries}>
					<button
						class="btn btn-outline btn-xs"
						slot="actions"
						on:click={() => JobListStore.removeEntry(job.id || '')}
					>
						<TrashIcon class="w-4 h-4" strokeWidth="2" />
					</button>
				</EntryCard>
			</li>
		{/each}
	</ul>
</section>
