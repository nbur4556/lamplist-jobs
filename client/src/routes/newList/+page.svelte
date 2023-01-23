<script lang="ts">
	import Input from '@src/lib/Form/Input.svelte';
	import JobList from '@src/lib/JobList/JobList.svelte';
	import { JobListStore } from '@src/store/JobListStore';

	let entry = '';
	const targetListSize = 40;

	const addEntry = () => {
		//TODO: Keep selection on entry input after submit for rapid data entry
		JobListStore.addEntry({ company: entry });
		entry = '';
	};

	$: jobLength = $JobListStore.length;
	$: remainingCount = jobLength < targetListSize ? -(jobLength - targetListSize) : 0;
</script>

<main>
	<h1>Welcome to Lamp List Jobs!</h1>
	<a href="/">back</a>

	<form on:submit={addEntry}>
		<Input bind:value={entry}>
			List {remainingCount}+ employers that you would like to work for
		</Input>

		<button type="submit">Submit</button>
	</form>

	<a href="/newList/populate">Next</a>

	<JobList />
</main>
