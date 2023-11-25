<script lang="ts">
	import TrashIcon from '@src/lib/Icons/TrashIcon.svelte';
	import { JobListStore } from '@src/store/JobListStore';
	import type { JobEntry } from '@src/store/JobListStore';
	import sortObjectList from '@src/utils/sortObjectList';
	import EntryCard from './EntryCard.svelte';

	export let sortIsReversed = false;
	export let sortBy: keyof(JobEntry);

	let collapsedEntries = false;

	const toggleCollapsedEntries = () => (collapsedEntries = !collapsedEntries);


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
