<script lang='ts'>
  import Entry from '../../../lib/JobList/Entry.svelte';
  import {JobListStore} from '../../../store';

  let entryId = 0;
  let step: 0 | 1 | 2 = 0; 

  const nextEntry = () => {
    const atMaxEntry = (entryId >= $JobListStore.length - 1);

    if(atMaxEntry && step >= 2) {
      return;
    }
    else if(atMaxEntry) {
      entryId = 0;
      step += 1;
      return;
    }

    entryId += 1;
  }

  const preEntry = () => {
    if(entryId <= 0 && step <= 0) {
      return;
    }
    else if (entryId <= 0) {
      entryId = $JobListStore.length - 1;
      step += -1;
      return;
    }

    entryId += -1;
  }
</script>

{#if step === 0}
  <p>Enter Contacts</p>
{:else if step === 1}
  <p>Enter Interest</p>
{:else if step === 2}
  <p>Enter Posting</p>
{/if}

<Entry job={$JobListStore[entryId]} index={entryId} />

<button on:click={preEntry}>Pre</button>
<button on:click={nextEntry}>Next</button>