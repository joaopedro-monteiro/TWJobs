﻿using TWJobs.Api.Commons.Assemblers;
using TWJobs.Api.Commons.Dtos;
using TWJobs.Api.Jobs.Dtos;

namespace TWJobs.Api.Jobs.Assemblers
{
    public class JobSummaryPagedAssembler(LinkGenerator linkGenerator, IAssembler<JobSummaryResponse> jobSummaryAssembler) : IPagedAssembler<JobSummaryResponse>
    {
        private readonly LinkGenerator _linkGenerator = linkGenerator;
        private readonly IAssembler<JobSummaryResponse> _jobSummaryAssembler = jobSummaryAssembler;
        public PagedResponse<JobSummaryResponse> ToPagedResource(PagedResponse<JobSummaryResponse> pagedResource, HttpContext context)
        {
            pagedResource.Items = _jobSummaryAssembler.ToResourceCollection(pagedResource.Items!, context);

            var firstPageLink = new LinkResponse(
                _linkGenerator.GetUriByName(context, "FindAllJobs",
                    new { page = pagedResource.FirstPage, size = pagedResource.PageSize }),
                "GET", 
                "firstPage");

            var lastPageLink = new LinkResponse(
                _linkGenerator.GetUriByName(context, "FindAllJobs",
                    new { page = pagedResource.LastPage, size = pagedResource.PageSize }),
                "GET",
                "lastPage");

            var nextPageLink = new LinkResponse(
                _linkGenerator.GetUriByName(context, "FindAllJobs",
                    new { page = pagedResource.PageNumber + 1, size = pagedResource.PageSize }),
                "GET",
                "nextPage");

            var previousPageLink = new LinkResponse(
                _linkGenerator.GetUriByName(context, "FindAllJobs",
                    new { page = pagedResource.PageNumber - 1, size = pagedResource.PageSize }),
                "GET",
                "previousPage");

            pagedResource.AddLinks(firstPageLink, lastPageLink);
            pagedResource.AddLinkIf(pagedResource.HasNextPage, nextPageLink);
            pagedResource.AddLinkIf(pagedResource.HasPreviousPage, previousPageLink);

            return pagedResource;
        }
    }
}
