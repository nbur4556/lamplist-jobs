<script lang='ts'>
  import Card from '@src/lib/Card.svelte';
	import type { JobEntry } from '@src/store/JobListStore';

  export let job: JobEntry;
</script>

<Card>
  <span slot="header">
    {job.company}
  </span>
  <div>
    <p>Contact: {#if job.contact}{job.contact}{/if}</p>
    <p>Interest: {#if job.interest}{job.interest}{/if}</p>
    <p>Posting: {#if job.posting}{job.posting}{/if}</p>
  </div>
</Card>

<style lang='scss'>
  @use '../theme/sizes';

  div {
    display: flex;
    flex-direction: column;
    gap: sizes.$spacing-sm;
  }
</style>
