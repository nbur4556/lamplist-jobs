import type { Updater } from 'svelte/store';

export type StoreSetter<T> = (setter: T) => void;
export type StoreUpdater<T> = (updater: Updater<T>) => void;
