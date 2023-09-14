<script lang="ts">
	import EntryCard from './EntryCard.svelte';
	import { JobListStore } from '@src/store/JobListStore';

	let collapsedEntries = false;

	const toggleCollapsedEntries = () => (collapsedEntries = !collapsedEntries);

	$: jobCount = $JobListStore.length;
</script>

<section class="flex flex-col self-stretch">
	<div class="flex justify-end items-center gap-3">
		<p>Jobs ({jobCount})</p>
		<button class="btn btn-outline btn-sm" on:click={toggleCollapsedEntries}>
			{#if !collapsedEntries}Collapse{:else}Expand{/if}
		</button>
	</div>
	<ul>
		{#each $JobListStore as job}
			<li class="py-2">
				<EntryCard {job} collapsed={collapsedEntries}>
					<button
						class="btn btn-outline btn-xs"
						slot="actions"
						on:click={() => JobListStore.removeEntry(job.id || '')}
					>
						Delete
					</button>
				</EntryCard>
			</li>
		{/each}
	</ul>
</section>
