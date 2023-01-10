<script lang='ts'>
  let jobList: Array<string> = [];
  let entry: string = '';

  const addEntry = () => {
    //TODO: Keep selection on entry input after submit for rapid data entry
    jobList = [...jobList, entry];
    entry = '';
  }
</script>

<h1>Welcome to Lamp List Jobs!</h1>

<form on:submit={addEntry}>
  <label>
    List 40+ employers that you would like to work for.
    <input type="text" bind:value={entry} />
  </label>
  
  <button type="submit">Submit</button>
</form>

<ul>
  {#each jobList as job}
    <li>{job}</li>
  {/each}
</ul>
