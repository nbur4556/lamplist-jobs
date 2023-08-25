<script>
	import JobList from '@src/lib/JobList/JobList.svelte';
	import PageContent from '@src/lib/UI/PageContent.svelte';
	import { AuthStore } from '@src/store/AuthStore';
	import { JobListStore } from '@src/store/JobListStore';

	$: authUserName = $AuthStore.userName;
</script>

<PageContent>
	<nav class="navbar">
		<section class="menu menu-horizontal gap-2">
			<a class="link link-secondary" href="/newList">Add Job Entries</a>
			<a class="link link-secondary" href="/auth/register">Register</a>
			<a class="link link-secondary" href="/auth/login">Login</a>
			<button class="link link-secondary" on:click={AuthStore.logout}>Logout</button>
		</section>
	</nav>

	<h1 class="text-xl">Welcome to Lamp List Jobs!</h1>

	{#if authUserName}
		<p>You are logged in as {authUserName}</p>
	{/if}

	{#if $JobListStore.length > 0}
		<JobList />
	{:else}
		<p>
			You do not yet have a lamp list... 
			<a class="link link-accent" href="/newList">
				Create one now!
			</a>
		</p>
	{/if}
</PageContent>
