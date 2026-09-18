export type CreateClipSegmentRequest = {
  startTime: number
  endTime: number
}

export type CreateClipRequest = {
  segments: CreateClipSegmentRequest[]
}