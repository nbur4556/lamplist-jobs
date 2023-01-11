<script lang='ts'>
  import Entry from '../../../lib/JobList/Entry.svelte';
  import {JobListStore} from '../../../store';

  interface FormValues {
    contact?: string,
    interest?: number,
    posting?: string,
  }

  let entryIndex = 0;
  let step: 0 | 1 | 2 = 0; 

  let formValues: FormValues = {
    contact: undefined,
    interest: undefined,
    posting: undefined,
  }

  const updateJobEntry = () => {
    let cleanValues: FormValues = {};

    for (const key in formValues)
    {
      if(!formValues[key as keyof FormValues]) {
        continue;
      }

      cleanValues = {
        ...cleanValues, 
        [key as keyof FormValues]: formValues[key as keyof FormValues]
      };
    }

    JobListStore.updateEntry({...cleanValues}, entryIndex);
    formValues = {
      contact: undefined,
      interest: undefined,
      posting: undefined,
    }
  }

  const nextEntry = () => {
    const atMaxEntry = (entryIndex >= $JobListStore.length - 1);

    if(atMaxEntry && step >= 2) {
      return;
    }
    else if(atMaxEntry) {
      entryIndex = 0;
      step += 1;
      return;
    }

    entryIndex += 1;
  }

  const preEntry = () => {
    if(entryIndex <= 0 && step <= 0) {
      return;
    }
    else if (entryIndex <= 0) {
      entryIndex = $JobListStore.length - 1;
      step += -1;
      return;
    }

    entryIndex += -1;
  }
</script>

<form>
  {#if step === 0}
      <label>
        Do you have a contact at this company? Enter their name:
        <input type="text" bind:value={formValues.contact} />
      </label>
  {:else if step === 1}
      <label>
        Enter your interest for this company on a scale of 0 - 3:
        <input type="number" min={0} max={3} bind:value={formValues.interest} />
      </label>
  {:else if step === 2}
      <label>
        Is there a current job posting? Enter the link here:
        <input type="text" bind:value={formValues.posting} />
      </label>
  {/if}
  <button type="submit" on:click={updateJobEntry}>Submit</button>
</form>

<Entry job={$JobListStore[entryIndex]} index={entryIndex} />

<button on:click={preEntry}>Pre</button>
<button on:click={nextEntry}>Next</button>