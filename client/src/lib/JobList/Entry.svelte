<script lang="ts">
	import { JobListStore } from '../../store';
	import type { JobEntry } from '../../store';

	export let job: JobEntry;
	export let index: number;
</script>

<li>
	Company: {job.company}
	{#if job.contact}Contact: {job.contact}{/if}
	{#if job.interest}Interest: {job.interest}{/if}
	{#if job.posting}Posting: {job.posting}{/if}
	<button on:click={() => JobListStore.removeEntry(index)}>X</button>
</li>
