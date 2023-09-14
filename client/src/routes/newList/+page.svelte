<script lang="ts">
	import Input from '@src/lib/Form/Input.svelte';
	import PageContent from '@src/lib/UI/PageContent.svelte';
	import { JobListStore } from '@src/store/JobListStore';

	
	let jobEntries = new Array<string>(10);

	const addEntry = () => {
		jobEntries.forEach(company => {
			JobListStore.addEntry({ company });
		})
	};
</script>

<PageContent>
	<nav class="w-full">
		<ul class="flex justify-between">
			<li><a class="link link-primary" href="/">Back</a></li>
			<li><a class="link link-primary" href="/newList/populate">Next</a></li>
		</ul>
	</nav>

	<!-- //TODO: should use 4 different categories from lamplist method -->
	<p>Add entries for 10 companies of CATEGORY</p>
	
	<form class="flex flex-col justify-between w-full" on:submit={addEntry}>
		{#each jobEntries as _, i}
			<Input name={`job-${i}`} value={jobEntries[i]} />
		{/each}
		<button class="btn btn-primary" type="submit">Submit</button>
	</form>
</PageContent>
