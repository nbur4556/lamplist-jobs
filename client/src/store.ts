import { writable } from 'svelte/store';

export const JobListStore = writable<Array<string>>([]);