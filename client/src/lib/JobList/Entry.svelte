<script lang="ts">
	import { JobListStore } from '@src/store/JobListStore';
	import type { JobEntry } from '@src/store/JobListStore';

	export let job: JobEntry;
</script>

<li>
	Company: {job.company}
	{#if job.contact !== undefined}Contact: {job.contact}{/if}
	{#if job.interest !== undefined}Interest: {job.interest}{/if}
	{#if job.posting !== undefined}Posting: {job.posting}{/if}
	<!-- //?: Can the blank string be removed form the 'removeEntry' parameter? -->
	<button on:click={() => JobListStore.removeEntry(job.id || '')}>X</button>
</li>
