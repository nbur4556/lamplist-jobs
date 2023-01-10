<script lang='ts'>
  export let job: string;
  export let index: number;
  export let removeEntry: (index: number) => void;
</script>

<li>
  {job}

  <button on:click={() => removeEntry(index)}>X</button>
</li>
