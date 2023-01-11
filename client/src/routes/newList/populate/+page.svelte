<script lang='ts'>
  import Entry from '../../../lib/JobList/Entry.svelte';
  import {JobListStore} from '../../../store';

  let entryIndex = 0;
  let step: 0 | 1 | 2 = 0; 
  let contact = '';
  let interest = 0;
  let posting = '';

  const updateJobContact = () => {
    JobListStore.updateEntry({contacts: [contact]}, entryIndex);
    contact = '';
  }
  
  const updateJobInterest  = () => {
    JobListStore.updateEntry({interest}, entryIndex);
    interest = 0;
  }

  const updateJobPosting = () => {
    JobListStore.updateEntry({posting}, entryIndex);
    posting = '';
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

  {#if step === 0}
    <form>
      <label>
        Do you have a contact at this company? Enter their name:
        <input type="text" bind:value={contact} />
      </label>

      <button type="submit" on:click={updateJobContact}>Submit</button>
    </form>
  {:else if step === 1}
    <form>
      <label>
        Enter your interest for this company on a scale of 0 - 3:
        <input type="text" bind:value={interest} />
      </label>

      <button type="submit" on:click={updateJobInterest}>Submit</button>
    </form>
  {:else if step === 2}
    <form>
      <label>
        Is there a current job posting? Enter the link here:
        <input type="text" bind:value={posting} />
      </label>

      <button type="submit" on:click={updateJobPosting}>Submit</button>
    </form>
  {/if}

<Entry job={$JobListStore[entryIndex]} index={entryIndex} />

<button on:click={preEntry}>Pre</button>
<button on:click={nextEntry}>Next</button>