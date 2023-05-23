<script lang="ts">
	import Entry from './Entry.svelte';
	import { JobListStore } from '@src/store/JobListStore';

	$: jobCount = $JobListStore.length;
</script>

<section>
	<p class="job-count">Jobs ({jobCount})</p>
	<ul>
		{#each $JobListStore as job}
			<Entry {job} />
		{/each}
	</ul>
</section>

<style>
	section {
		display: flex;
		flex-direction: column;
	}

	.job-count {
		align-self: flex-end;
	}
</style>
