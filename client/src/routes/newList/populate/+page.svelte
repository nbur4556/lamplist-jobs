<script lang="ts">
	import { fade, fly } from 'svelte/transition';

	import Input from '@src/lib/Form/Input.svelte';
	import InputNumber from '@src/lib/Form/InputNumber.svelte';
	import EntryCard from '@src/lib/EntryCard.svelte';
	import PageContent from '@src/lib/UI/PageContent.svelte';
	import { JobListStore } from '@src/store/JobListStore';
	import removeEmptyKeys from '@src/utils/removeEmptyKeys';

	interface FormValues {
		contact?: string;
		interest?: number;
		posting?: string;
	}

	let animateLeft = false;
	let entryIndex = 0;
	let step: 0 | 1 | 2 = 0;
	let formValues: FormValues = {
		contact: undefined,
		interest: undefined,
		posting: undefined
	};

	$: maxInStep = entryIndex >= $JobListStore.length - 1;
	$: minInStep = entryIndex <= 0;
	$: lastEntry = maxInStep && step >= 2;
	$: firstEntry = minInStep && step <= 0;
	$: animatePos = animateLeft ? 1000 : -1000;

	const updateJobEntry = async () => {
		const id = $JobListStore[entryIndex].id || '';
		const cleanValues = removeEmptyKeys<FormValues>(formValues);
		await JobListStore.updateEntry({ ...cleanValues }, id);
		formValues = {
			contact: undefined,
			interest: undefined,
			posting: undefined
		};
	};

	const nextEntry = () => {
		animateLeft = true;
		updateJobEntry();

		if (lastEntry) {
			return;
		} else if (maxInStep) {
			entryIndex = 0;
			step += 1;
			return;
		}

		entryIndex += 1;
	};

	const preEntry = () => {
		animateLeft = false;

		if (firstEntry) {
			return;
		} else if (minInStep) {
			entryIndex = $JobListStore.length - 1;
			step += -1;
			return;
		}

		entryIndex += -1;
	};
</script>

<PageContent>
	<form>
		<Input bind:value={formValues.contact} hidden={step !== 0}>
			Do you have a contact at this company? Enter their name:
		</Input>
		<InputNumber bind:value={formValues.interest} min={0} max={3} hidden={step !== 1}>
			Enter your interest for this company on a scale of 0 - 3:
		</InputNumber>
		<Input bind:value={formValues.posting} hidden={step !== 2}>
			Is there a current job posting? Enter the link here:
		</Input>
	</form>

	<section class="controls">
		{#if lastEntry}
			<a href="/"><button>Save</button></a>
		{:else}
			<button on:click={nextEntry}>Next</button>
		{/if}

		{#if !firstEntry}
			<button on:click={preEntry}>Pre</button>
		{:else}
			<a href="/"><button>Back</button></a>
		{/if}
	</section>

	<section>
		{#each $JobListStore as jobEntry, index}
			{#if entryIndex === index}
				<div
					class="animator"
					in:fly|local={{ x: animatePos, duration: 500 }}
					out:fade={{ duration: 100 }}
				>
					<EntryCard job={jobEntry} />
				</div>
			{/if}
		{/each}
	</section>
</PageContent>

<!-- //TODO: Entry Card is not scaling on this screen -->
<style lang="scss">
	section {
		width: 100%;
	}

	form {
		width: 100%;
	}

	.controls {
		display: flex;
		flex-direction: row-reverse;
		justify-content: space-between;
	}
</style>
