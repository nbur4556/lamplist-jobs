import { writable } from 'svelte/store';

export interface JobEntry {
  company: string;
  contacts?: Array<string>;
  //TODO: Should be on a scale of 0 - 3
  interest?: number;
  posting?: string;
}

const createJobListStore = () => {
  const { subscribe, update } = writable<Array<JobEntry>>([]);

  const updateEntry = (entryData: Partial<JobEntry>, index: number) => {
    update((state) => {
      state[index] = {...state[index], ...entryData};
      return state;
    });
  }

  return {
    subscribe,
    updateEntry,
    addEntry: (entry: JobEntry) => update(state => [...state, entry]),
    removeEntry: (index: number) => update(state => state.filter((val, i) => i !== index))
  }
}

export const JobListStore = createJobListStore();