<script lang="ts">
	import Input from '@src/lib/Form/Input.svelte';
	import InputNumber from '@src/lib/Form/InputNumber.svelte';
	import Entry from '@src/lib/JobList/Entry.svelte';
	import { JobListStore } from '@src/store';

	interface FormValues {
		contact?: string;
		interest?: number;
		posting?: string;
	}

	const formDefault: FormValues = {
		contact: undefined,
		interest: undefined,
		posting: undefined
	};

	let entryIndex = 0;
	let step: 0 | 1 | 2 = 0;
	let formValues: FormValues = formDefault;

	$: maxInStep = entryIndex >= $JobListStore.length - 1;
	$: minInStep = entryIndex <= 0;
	$: lastEntry = maxInStep && step >= 2;
	$: firstEntry = minInStep && step <= 0;

	const updateJobEntry = () => {
		let cleanValues: FormValues = {};

		for (const k in formValues) {
			const key = k as keyof FormValues;

			if (formValues[key] === undefined) {
				continue;
			}

			cleanValues = { ...cleanValues, [key]: formValues[key] };
		}

		JobListStore.updateEntry({ ...cleanValues }, entryIndex);
		formValues = formDefault;
	};

	const nextEntry = () => {
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

<form>
	{#if step === 0}
		<Input bind:value={formValues.contact}>
			Do you have a contact at this company? Enter their name:
		</Input>
	{:else if step === 1}
		<InputNumber bind:value={formValues.interest} min={0} max={3}>
			Enter your interest for this company on a scale of 0 - 3:
		</InputNumber>
	{:else if step === 2}
		<Input bind:value={formValues.posting}>
			Is there a current job posting? Enter the link here:
		</Input>
	{/if}
	<button on:click={preEntry}>Pre</button>

	{#if lastEntry}
		<a href="/"><button on:click={nextEntry}>Save</button></a>
	{:else}
		<button on:click={nextEntry}>Next</button>
	{/if}
</form>

<Entry job={$JobListStore[entryIndex]} index={entryIndex} />
