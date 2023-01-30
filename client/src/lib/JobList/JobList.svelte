<script lang="ts">
	import Entry from './Entry.svelte';
	import { JobListStore } from '@src/store/JobListStore';

	$: jobCount = $JobListStore.length;
</script>

<h2>Job List ({jobCount})</h2>
<ul>
	{#each $JobListStore as job, index}
		<Entry {job} />
	{/each}
</ul>
