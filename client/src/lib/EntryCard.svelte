<script lang='ts'>
  import Card from '@src/lib/Card.svelte';
	import type { JobEntry } from '@src/store/JobListStore';

  export let job: JobEntry;
</script>

<Card>
  <span slot="header">
    {job.company}
  </span>
  <!-- //TODO: Organize Content -->
  {#if job.contact}{job.contact}{/if}
  {#if job.interest}{job.interest}{/if}
  {#if job.posting}{job.posting}{/if}
</Card>
