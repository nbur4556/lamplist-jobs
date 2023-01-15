import type { Updater } from 'svelte/store';
import type { JobEntry } from '@src/store/JobListStore';

export type StoreUpdater = (updater: Updater<JobEntry[]>) => void;
