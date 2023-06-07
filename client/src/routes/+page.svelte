<script>
	import JobList from '@src/lib/JobList/JobList.svelte';
	import PageContent from '@src/lib/UI/PageContent.svelte';
	import { AuthStore } from '@src/store/AuthStore';
	import { JobListStore } from '@src/store/JobListStore';

	$: authUserName = $AuthStore.userName;
</script>

<PageContent>
	<h1>Welcome to Lamp List Jobs!</h1>

	<a href="/newList">Add Job Entries</a>
	<a href="/auth/register">Register</a>
	<a href="/auth/login">Login</a>

	{#if authUserName}
		<p>You are logged in as {authUserName}</p>
	{/if}

	{#if $JobListStore.length > 0}
		<JobList />
	{:else}
		<p class="cta-msg">You do not yet have a lamp list... <a href="/newList">Create one now!</a></p>
	{/if}
</PageContent>

<style lang="scss">
	@use '../theme/colors';
	@use '../theme/sizes';

	h1 {
		font-size: sizes.$font-lg;
	}

	.cta-msg {
		font-size: sizes.$font-md;

		a {
			font-size: sizes.$font-xl;
			color: colors.$accent-mid;

			&:hover {
				color: colors.$accent-light;
			}
		}
	}
</style>
