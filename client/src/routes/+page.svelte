<script lang="ts">
	import JobList from '@src/lib/JobList/JobList.svelte';
	import NavigationBar from '@src/lib/NavigationBar.svelte';
	import PageContent from '@src/lib/UI/PageContent.svelte';
	import { AuthStore } from '@src/store/AuthStore';
	import { JobListStore } from '@src/store/JobListStore';
	import type { JobEntry } from '@src/store/JobListStore';

	let sortBy: keyof(JobEntry) = 'contact';
	let sortIsReversed = false;

	$: authUserName = $AuthStore.userName;
</script>

<PageContent>
	<NavigationBar>
		<svelte:fragment slot="left">
			<a class="link link-primary" href="/newList">Add Job Entries</a>
			<a class="link link-secondary" href="/auth/register">Register</a>
			<a class="link link-secondary" href="/auth/login">Login</a>
			<button class="link link-secondary" on:click={AuthStore.logout}>Logout</button>
		</svelte:fragment>
	</NavigationBar>

	<h1 class="text-2xl">Welcome to Lamplist Jobs!</h1>

	{#if authUserName}
		<p class="text-secondary">You are logged in as {authUserName}</p>
	{/if}

	{#if $JobListStore.length > 0}
		<JobList {sortBy} {sortIsReversed}>
			<svelte:fragment slot="controls">
				<label for="sort">
					Sort by
					<select name="sort" class="select select-xs" bind:value={sortBy}>
						<option value="company">Company</option>
						<option value="contact">Contact</option>
						<option value="interest">Interest</option>
						<option value="posting">Posting</option>
					</select>
				</label>

				<label for="reverse">
					Reverse
					<input
						name="reverse"
						type="checkbox"
						class="checkbox checkbox-xs"
						bind:checked={sortIsReversed}
					/>
				</label>
			</svelte:fragment>
		</JobList>
	{:else}
		<p class="self-start">The LAMP list is a simple but strategic job search method.</p>
		<p class="selt-start">
			Having this focused list keeps your job search efficient and optimized. Networking within your
			LAMP connections gives you a competitive advantage in getting noticed and landing interviews.
			The LAMP method provides a strategic approach to uncovering hidden job opportunities.
		</p>
		<a class="btn btn-accent" href="/newList">Create your LAMP List</a>
	{/if}
</PageContent>
