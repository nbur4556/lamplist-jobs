import type { Updater } from 'svelte/store';

export type StoreUpdater<T> = (updater: Updater<T>) => void;
export type StoreSetter<T> = (setter: T) => void