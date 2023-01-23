<script lang="ts">
	import Input from '@src/lib/Form/Input.svelte';
	import InputNumber from '@src/lib/Form/InputNumber.svelte';
	import EntryCard from '@src/lib/EntryCard.svelte';
	import { JobListStore } from '@src/store/JobListStore';
	import removeEmptyKeys from '@src/utils/removeEmptyKeys';

	interface FormValues {
		contact?: string;
		interest?: number;
		posting?: string;
	}

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

	const updateJobEntry = async () => {
		const cleanValues = removeEmptyKeys<FormValues>(formValues);
		await JobListStore.updateEntry({ ...cleanValues }, entryIndex);
		formValues = {
			contact: undefined,
			interest: undefined,
			posting: undefined
		};
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

<main>
	<!-- //! Some inputs are not clearing on next -->
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
		<button on:click={preEntry}>Pre</button>

		{#if lastEntry}
			<a href="/"><button on:click={nextEntry}>Save</button></a>
		{:else}
			<button on:click={nextEntry}>Next</button>
		{/if}
	</form>

	<EntryCard job={$JobListStore[entryIndex]} />
</main>
