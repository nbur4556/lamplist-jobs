import type { Updater } from "svelte/store";

import type { JobEntry } from "@src/store";

const fetchJobEntries = async (update: (updater: Updater<JobEntry[]>) => void) => {
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

export default fetchJobEntries;