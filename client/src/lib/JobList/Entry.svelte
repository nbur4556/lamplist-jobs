<script lang="ts">
	import EntryCard from '@src/lib/EntryCard.svelte';
	import { JobListStore } from '@src/store/JobListStore';
	import type { JobEntry } from '@src/store/JobListStore';

	export let job: JobEntry;

	$: id = job.id || '';
</script>

<li>
	<EntryCard {job} />
	<button on:click={() => JobListStore.removeEntry(id)}>X</button>
</li>

<style lang="scss">
	@use '../../theme/colors';
	@use '../../theme/sizes';

	li {
		display: flex;
		flex-direction: row;
	}

	button {
		margin: sizes.$spacing-sm 0;

		color: colors.$txt-main;
		background-color: colors.$bg-mid;
		border: none;
		border-radius: 10px;
	}
</style>
