<script lang='ts'>
  import Entry from './Entry.svelte';
  export let jobList: Array<string>;
  $: jobCount = jobList.length;
</script>

<h2>Job List ({jobCount})</h2>
<ul>
  {#each jobList as job}
    <Entry {job} />
  {/each}
</ul>