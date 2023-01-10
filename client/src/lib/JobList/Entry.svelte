<script lang='ts'>
  import {JobListStore} from '../../store';

  export let job: string;
  export let index: number;

  const removeEntry = () => JobListStore.update((currentState) => {
    return currentState.filter((val, i) => i !== index);
  });
</script>

<li>
  {job}

  <button on:click={removeEntry}>X</button>
</li>
