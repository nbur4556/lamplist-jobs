<script lang="ts">
	import Input from '@src/lib/Form/Input.svelte';
	import JobList from '@src/lib/JobList/JobList.svelte';
	import PageContent from '@src/lib/UI/PageContent.svelte';
	import { JobListStore } from '@src/store/JobListStore';

	let entry = '';
	const targetListSize = 40;

	const addEntry = () => {
		JobListStore.addEntry({ company: entry });
		entry = '';
	};

	$: jobLength = $JobListStore.length;
	$: remainingCount = jobLength < targetListSize ? -(jobLength - targetListSize) : 0;
</script>

<PageContent>
	<form class="flex justify-between items-end w-full" on:submit={addEntry}>
		<Input name="job" bind:value={entry}>
			List {remainingCount}+ employers that you would like to work for:
		</Input>
		<button class="btn btn-primary" type="submit">Submit</button>
	</form>

	<nav class="w-full">
		<ul class="flex justify-between">
			<li><a class="link link-primary" href="/">Back</a></li>
			<li><a class="link link-primary" href="/newList/populate">Next</a></li>
		</ul>
	</nav>

	<JobList />
</PageContent>
