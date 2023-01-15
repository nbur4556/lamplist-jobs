import { writable } from 'svelte/store';

export interface JobEntry {
	company: string;
	//TODO: Should be an array of contacts
	contact?: string;
	//TODO: Should be on a scale of 0 - 3
	interest?: number;
	posting?: string;
}

const createJobListStore = () => {
	const { subscribe, update } = writable<Array<JobEntry>>([]);

  const fetchEntries = async () => {
    try {
      //TODO: Use environment to handle server url
      const response = await (await fetch("http://localhost:5000/api/joblist")).json();
      update(() => response);
    }
    catch(err) {
      //TODO: Error Handling
      console.error(err);
    }
  };

	const updateEntry = (entryData: Partial<JobEntry>, index: number) => {
		update((state) => {
			state[index] = { ...state[index], ...entryData };
			return state;
		});
	};

	return {
		subscribe,
    fetchEntries,
		updateEntry,
		addEntry: (entry: JobEntry) => update((state) => [...state, entry]),
		removeEntry: (index: number) => update((state) => state.filter((val, i) => i !== index))
	};
};

export const JobListStore = createJobListStore();
