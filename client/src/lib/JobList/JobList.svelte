<script lang='ts'>
  import Entry from './Entry.svelte';

  export let jobList: Array<string>;
  export let removeEntry: (index: number) => void;

  $: jobCount = jobList.length;
</script>

<h2>Job List ({jobCount})</h2>
<ul>
  {#each jobList as job, index}
    <Entry {job} {index} {removeEntry} />
  {/each}
</ul>