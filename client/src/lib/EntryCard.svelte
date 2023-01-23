<script lang="ts">
	import Card from '@src/lib/Card.svelte';
	import type { JobEntry } from '@src/store/JobListStore';

	export let job: JobEntry;
</script>

<Card>
  <span slot="header" class="bold">
    <h3>{job.company}</h3>
  </span>
  <div>
    <p>
      <span class="bold">Contact:</span> {#if job.contact}{job.contact}{/if}
    </p>
    <p>
      <span class="bold">Interest:</span> {#if job.interest}{job.interest}{/if}
    </p>
    <p>
      <span class="bold">Posting:</span> {#if job.posting}{job.posting}{/if}
    </p>
  </div>
</Card>

<style lang="scss">
  @use '../theme/fonts';
	@use '../theme/sizes';

	div {
		display: flex;
		flex-direction: column;
		gap: sizes.$spacing-md;
    width: 40rem;
    height: 10rem
	}

  h3 {
    font-size: fonts.$size-lg;
  }

  .bold {
    font-weight: fonts.$bold;
  }
</style>
