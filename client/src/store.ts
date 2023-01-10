import { writable } from 'svelte/store';

const createJobListStore = () => {
  const { subscribe, update } = writable<Array<string>>([]);

  console.log('custom store');

  return {
    subscribe,
    addEntry: (entry: string) => update(state => [...state, entry]),
    removeEntry: (index: number) => update(state => state.filter((val, i) => i !== index))
  }
}

export const JobListStore = createJobListStore();