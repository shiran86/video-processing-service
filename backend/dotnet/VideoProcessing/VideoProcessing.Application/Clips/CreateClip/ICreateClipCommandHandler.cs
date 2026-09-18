using System;
using System.Collections.Generic;
using System.Text;

namespace VideoProcessing.Application.Clips.CreateClips
{
    public interface ICreateClipCommandHandler
    {
       public Task<CreateClipResponse> Handle(CreateClipCommand command);
    }
}
