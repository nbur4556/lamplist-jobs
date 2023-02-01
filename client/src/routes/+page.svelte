<script>
	import JobList from '@src/lib/JobList/JobList.svelte';
	import { AuthStore } from '@src/store/AuthStore';
	import { JobListStore } from '@src/store/JobListStore';

	$: authUserName = $AuthStore.userName;
</script>

<main>
	<h1>Welcome to Lamp List Jobs!</h1>

	<a href="/newList">New Lamp List</a>
	<a href="/auth/register">Register</a>
	<a href="/auth/login">Login</a>

	{#if authUserName}
		<p>You are logged in as {authUserName}</p>
	{/if}

	{#if $JobListStore.length > 0}
		<JobList />
	{:else}
		<p>No lamp list yet... Create one above!</p>
	{/if}
</main>
