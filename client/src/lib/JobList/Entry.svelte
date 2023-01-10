<script lang='ts'>
  import {JobListStore} from '../../store';
  import type {JobEntry} from '../../store';

  export let job: JobEntry;
  export let index: number;
</script>

<li>
  {job.company}
  <button on:click={() => JobListStore.removeEntry(index)}>X</button>
</li>
