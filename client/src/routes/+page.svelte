<script>
	import JobList from '@src/lib/JobList/JobList.svelte';
	import { JobListStore } from '@src/store/JobListStore';
</script>

<main>
	<h1>Welcome to Lamp List Jobs!</h1>

	<a href="/newList">New Lamp List</a>

	{#if $JobListStore.length > 0}
		<JobList />
	{:else}
		<p>No lamp list yet... Create one above!</p>
	{/if}
</main>
