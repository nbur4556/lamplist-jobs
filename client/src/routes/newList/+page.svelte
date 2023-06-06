<script lang="ts">
	import JobList from '@src/lib/JobList/JobList.svelte';
	import PageContent from '@src/lib/UI/PageContent.svelte';
	import { JobListStore } from '@src/store/JobListStore';

	let entry = '';
	const targetListSize = 40;

	const addEntry = () => {
		//! Add entry should not require an id, this should be created by the backend
		JobListStore.addEntry({ company: entry });
		entry = '';
	};

	$: jobLength = $JobListStore.length;
	$: remainingCount = jobLength < targetListSize ? -(jobLength - targetListSize) : 0;
</script>

<PageContent>
	<form on:submit={addEntry}>
		<label for="job">List {remainingCount}+ employers that you would like to work for:</label>
		<input name="job" type="text" bind:value={entry} />
		<button type="submit">Submit</button>
	</form>

	<nav>
		<ul>
			<li><a href="/">Back</a></li>
			<li><a href="/newList/populate">Next</a></li>
		</ul>
	</nav>

	<JobList />
</PageContent>

<style lang="scss">
	form {
		display: flex;
		justify-content: space-between;
		width: 100%;
	}

	nav {
		align-self: stretch;

		ul {
			display: flex;
			justify-content: space-between;
			align-self: stretch;
		}
	}
</style>
