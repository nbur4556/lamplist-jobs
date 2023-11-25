<script lang="ts">
	import TrashIcon from '@src/lib/Icons/TrashIcon.svelte';
	import { JobListStore } from '@src/store/JobListStore';
	import type { JobEntry } from '@src/store/JobListStore';
	import EntryCard from './EntryCard.svelte';

	//? What is the best way to do this type? Is it already defined? KeyOf(job)
	type SortBy = 'company' | 'contact' | 'interest' | 'posting';

	//TODO: Sort direction
	export let sortIsReversed = false;
	export let sortBy: SortBy;

	let collapsedEntries = false;

	const toggleCollapsedEntries = () => (collapsedEntries = !collapsedEntries);

	//! Undefined values do not get sorted, should be at the end
	//TODO: refactor as a utility function
	//TODO: thoroughly test this function
	const sortObjectList = <T>(list: Array<T>, term: keyof(T), reversed: boolean): Array<T> => {
		//TODO: Remove any types
		const checkComparison = (a: any, b: any, reversed: boolean) => {
			//TODO: fix "may be undefined" type error
			return reversed ? a > b : a < b;
		};

		let sortedList: Array<T> = [];
		list.forEach((enty) => {
			for (let i = 0; i < sortedList.length; i++) {
				if (checkComparison(enty[term], sortedList[i][term], reversed)) {
					sortedList = [...sortedList.slice(0, i), enty, ...sortedList.slice(i, sortedList.length)];
					return;
				}
			}
			sortedList = [...sortedList, enty];
		});
		return sortedList;
	};

	$: jobCount = $JobListStore.length;
	$: sortedList = sortObjectList<JobEntry>($JobListStore, sortBy, sortIsReversed);
</script>

<section class="flex flex-col self-stretch">
	<div class="flex justify-end items-center gap-3">
		<slot name="controls" />
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
