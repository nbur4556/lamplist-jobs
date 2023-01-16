import { JobListStore } from '@src/store/JobListStore';

export function load() {
	const unsubscribe = JobListStore.subscribe((jobList) => {
		if (jobList.length <= 0) {
			JobListStore.fetchEntries();
		}
	});

	unsubscribe();
}
