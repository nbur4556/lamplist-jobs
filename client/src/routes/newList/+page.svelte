<script lang='ts'>
  import JobList from '../../lib/JobList/JobList.svelte';
  import {JobListStore} from '../../store';

  let entry: string = '';
  const targetListSize = 40;

  const addEntry = () => {
    //TODO: Keep selection on entry input after submit for rapid data entry
    JobListStore.addEntry({company: entry});
    entry = '';
  }

  $: jobLength = $JobListStore.length
  $: remainingCount = (jobLength < targetListSize) ? -(jobLength - targetListSize) : 0;
</script>

<h1>Welcome to Lamp List Jobs!</h1>
<a href="/">back</a>

<form on:submit={addEntry}>
  <label>
    List {remainingCount}+ employers that you would like to work for
    <input type="text" bind:value={entry} />
  </label>
  
  <button type="submit">Submit</button>
</form>

<a href="/newList/populate">Next</a>

<JobList />
