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
