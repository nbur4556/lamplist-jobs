<script>
	import JobList from '@src/lib/JobList/JobList.svelte';
	import { JobListStore } from '@src/store/JobListStore';
</script>

<h1>Welcome to Lamp List Jobs!</h1>

<a href="/newList">Add Job Entries</a>

{#if $JobListStore.length > 0}
	<JobList />
{:else}
	<p class="cta-msg">You do not yet have a lamp list... <a href="/newList">Create one now!</a></p>
{/if}

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
