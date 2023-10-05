<script lang="ts">
	import { goto } from '$app/navigation';

	import categories from '@src/content/listCategories.json';
	import Input from '@src/lib/Form/Input.svelte';
	import NavigationBar from '@src/lib/NavigationBar.svelte';
	import Modal from '@src/lib/UI/Modal.svelte';
	import MiniButton from '@src/lib/UI/MiniButton.svelte';
	import PageContent from '@src/lib/UI/PageContent.svelte';
	import { JobListStore } from '@src/store/JobListStore';
	import Timer from '@src/lib/Timer.svelte';

	const timePerCategory = 10;

	let resetTimer: () => void;
	let timerComplete = false;
	let showInstructions = true;
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
		resetTimer();
		timerComplete = false;

		if (categoryIndex >= categories.length - 1) {
			goto('/newList/populate');
			return;
		}

		categoryIndex++;
	};

	const handleTimerComplete = (remaining: number) => {
		if (remaining <= 0) {
			timerComplete = true;
		}
	};
</script>

<PageContent>
	<NavigationBar>
		<a slot="left" class="link link-primary" href="/">Back</a>
		<MiniButton slot="right" onClick={() => (showInstructions = true)}>?</MiniButton>
	</NavigationBar>

	<Modal bind:isOpen={showInstructions}>
		<p>
			You will create your Lamp List by entering 10 companies for each of the following
			categories:
		</p>

		<ul>
			{#each categories as category}
				<li class="my-2">
					<!-- //TODO: Should be capitalized here -->
					<p>{category.title}</p>
					<p>{category.description}</p>
				</li>
			{/each}
		</ul>

		<p>
			Add as close to 10 entries for each category as possible. However, you may reduce or increase
			the amount if necessary. Try to take no longer than 10 minutes per category. You may use the
			timer to keep track of your time spent
		</p>
	</Modal>

	<p>Add 10 entries for {categories[categoryIndex].title}</p>
	<p>{categories[categoryIndex].description}</p>

	<div class="flex justify-between w-full">
		<Timer time={timePerCategory} onStopTime={handleTimerComplete} bind:resetTimer />
		<div class="flex gap-2">
			<MiniButton onClick={removeFromForm}>-</MiniButton>
			<MiniButton onClick={addToForm}>+</MiniButton>
		</div>
	</div>

	{#if timerComplete}
		<p class="self-start">Time is up, please finish the category when you are ready.</p>
	{/if}

	<!-- //? Should this be a form? If so goto does not work. May need to handle using use:enhance if a form is needed -->
	<section class="flex flex-col justify-between w-full">
		{#each jobEntries as _, i}
			<Input name={`job-${i}`} bind:value={jobEntries[i]} />
		{/each}
		<button class="btn btn-primary mt-4" on:click={addEntries}>Submit</button>
	</section>
</PageContent>
