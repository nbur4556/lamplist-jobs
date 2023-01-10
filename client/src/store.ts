import { writable } from 'svelte/store';

export interface JobEntry {
  company: string;
  contacts?: Array<string>;
  interest?: number;
  posting?: string;
}

const createJobListStore = () => {
  const { subscribe, update } = writable<Array<JobEntry>>([]);

  return {
    subscribe,
    addEntry: (entry: JobEntry) => update(state => [...state, entry]),
    removeEntry: (index: number) => update(state => state.filter((val, i) => i !== index))
  }
}

export const JobListStore = createJobListStore();