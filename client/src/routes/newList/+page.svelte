<script lang="ts">
	import categories from '@src/content/listCategories.json';
	import Input from '@src/lib/Form/Input.svelte';
	import PageContent from '@src/lib/UI/PageContent.svelte';
	import { JobListStore } from '@src/store/JobListStore';

	let categoryIndex = 0;
	let jobEntries = new Array<string>(10);

	const addEntries = () => {
		jobEntries.forEach((company) => {
			JobListStore.addEntry({ company });
		});
		initializeCategory();
	};

	const addToForm = () => {
		jobEntries = [...jobEntries, ...new Array<string>(1)];
	};

	const removeFromForm = () => {
		jobEntries = jobEntries.slice(0, jobEntries.length - 1);
	};

	const initializeCategory = () => {
		jobEntries = new Array(10);

		if (categoryIndex >= categories.length - 1) {
			//TODO: Should route to the populating step
			return;
		}

		categoryIndex++;
	};
</script>

<PageContent>
	<nav class="w-full">
		<ul class="flex justify-between">
			<li><a class="link link-primary" href="/">Back</a></li>
			<li><a class="link link-primary" href="/newList/populate">Next</a></li>
		</ul>
	</nav>

	<p>Add 10 entries for {categories[categoryIndex].title}</p>
	<p>{categories[categoryIndex].description}</p>

	<div class="flex self-end gap-3">
		<button class="btn btn-outline btn-xs" on:click={removeFromForm}>-</button>
		<button class="btn btn-outline btn-xs" on:click={addToForm}>+</button>
	</div>

	<form class="flex flex-col justify-between w-full" on:submit={addEntries}>
		{#each jobEntries as _, i}
			<Input name={`job-${i}`} bind:value={jobEntries[i]} />
		{/each}
		<button class="btn btn-primary" type="submit">Submit</button>
	</form>
</PageContent>
