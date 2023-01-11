<script lang='ts'>
  import Entry from '../../../lib/JobList/Entry.svelte';
  import {JobListStore} from '../../../store';

  let entryId = 0;

  const nextEntry = () => entryId += 1;
  const preEntry = () => entryId += -1;
</script>

<Entry job={$JobListStore[entryId]} index={entryId} />

<button on:click={preEntry}>Pre</button>
<button on:click={nextEntry}>Next</button>