<script>
  import JobList from '../lib/JobList/JobList.svelte';
	import { JobListStore } from '../store';
</script>

<h1>Welcome to Lamp List Jobs!</h1>

<a href="/newList">New Lamp List</a>

{#if $JobListStore.length > 0}
  <JobList />
{:else}
  <p>No lamp list yet... Create one above!</p>
{/if}