<script lang='ts'>
  import {JobListStore} from '../../store';

  export let job: string;
  export let index: number;
</script>

<li>
  {job}
  <button on:click={() => JobListStore.removeEntry(index)}>X</button>
</li>
