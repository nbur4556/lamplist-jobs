<script lang='ts'>
  let jobList: Array<string> = [];
  let entry: string = '';

  const targetListSize = 10;

  const addEntry = () => {
    //TODO: Keep selection on entry input after submit for rapid data entry
    jobList = [...jobList, entry];
    entry = '';
  }

  $: jobCount = jobList.length;
  $: remainingCount = (jobCount < targetListSize) ? -(jobCount - targetListSize) : 0;
</script>

<h1>Welcome to Lamp List Jobs!</h1>

<form on:submit={addEntry}>
  <label>
    List {remainingCount}+ employers that you would like to work for
    <input type="text" bind:value={entry} />
  </label>
  
  <button type="submit">Submit</button>
</form>

<h2>Job List ({jobCount})</h2>
<ul>
  {#each jobList as job}
    <li>{job}</li>
  {/each}
</ul>
