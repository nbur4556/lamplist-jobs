<script lang="ts">
	import Input from '@src/lib/Form/Input.svelte';
	import JobList from '@src/lib/JobList/JobList.svelte';
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

<form on:submit={addEntry}>
	<Input bind:value={entry}>
		List {remainingCount}+ employers that you would like to work for
	</Input>

	<button type="submit">Submit</button>
</form>

<nav>
	<ul>
		<li><a href="/">Back</a></li>
		<li><a href="/newList/populate">Next</a></li>
	</ul>
</nav>

<JobList />

<style lang="scss">
	nav {
		width: 600px;

		ul {
			display: flex;
			justify-content: space-between;
			align-self: stretch;
		}
	}
</style>
