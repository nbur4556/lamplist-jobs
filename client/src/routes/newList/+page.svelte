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
	import { upperCaseWordsInSentence } from '@src/utils/stringFormatting';

	const timePerCategory = 600;

	let resetTimer: () => void;
	let showInstructions: () => void;
	let timerComplete = false;
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
		<MiniButton slot="right" onClick={showInstructions}>?</MiniButton>
	</NavigationBar>

	<Modal bind:openModal={showInstructions} contentClass="flex flex-col gap-2">
		<p class="font-semibold">Help</p>
		<p>
			To build your LAMP list, please add approximately 10 entries for each of the 4 categories:
		</p>

		<ul>
			{#each categories as category}
				<li class="my-2">
					<p class="font-semibold">{upperCaseWordsInSentence(category.title)}</p>
					<p class="text-sm">{category.description}</p>
				</li>
			{/each}
		</ul>

		<p>
			The goal is to populate your LAMP list with enough potential employers to give you a solid
			starting point. Quality matters more than quantity here. You may use the plus and minus
			buttons to adjust the number of entries up or down as needed.
		</p>
		<p>
			A 10-minute timer is provided for each category. This acts as a guide to keep you moving
			through the process efficiently. Don't worry if you can't fully complete a category in that
			time - simply move on to the next one.
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
		<p class="self-start">Time is up. When you are finished please move on to the next category.</p>
	{/if}

	<!-- //? Should this be a form? If so goto does not work. May need to handle using use:enhance if a form is needed -->
	<section class="flex flex-col justify-between w-full">
		{#each jobEntries as _, i}
			<Input name={`job-${i}`} bind:value={jobEntries[i]} />
		{/each}
		<button class="btn btn-primary mt-4" on:click={addEntries}>Submit</button>
	</section>
</PageContent>
