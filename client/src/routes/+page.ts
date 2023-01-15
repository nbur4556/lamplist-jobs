import { JobListStore } from '@src/store';

export function load () {
  const unsubscribe = JobListStore.subscribe(jobList => {
    if (jobList.length <= 0) { JobListStore.fetchEntries() }
  });

  unsubscribe();
}